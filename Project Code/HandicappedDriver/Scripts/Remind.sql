USE [HandicappedDriver]
GO

/****** Object:  StoredProcedure [dbo].[RemindParkLeave]    Script Date: 12/6/2019 8:46:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[RemindParkLeave] 
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @txt VARCHAR(255);

	SET @txt = ' >>> This is a reminder that you have a Parking Reservation waiting for you on campus at: ';

	insert into Email_Message (Receiver_ID, Status_ID, SentTime, MessageText, Res_id, msg_type)
	select Driver_id AS reciever_id, 1 AS status_id, GETDATE() AS senttime, 
		  Fullname + @txt + CAST(FromTime AS VARCHAR(20)) as MessageText, Reservation.id, 'REMINDAPPT' from reservation
				INNER JOIN reservationstatus ON reservation.Status_ID = ReservationStatus.id 
				INNER JOIN driver ON reservation.Driver_ID = driver.id
		  where statusdesc = 'PENDING' AND DATEDIFF(MINUTE, GETDATE(), FromTime) < 15 AND 
				Reservation.id NOT IN 
				  (SELECT em2.Res_ID FROM EMail_Message em2 WHERE  
				    (em2.msg_type='REMINDAPPT' AND em2.Status_ID=2));

	SET @txt = ' >>> This is a reminder that your Parking Appointment is overdue.' +
		'Please use the Parking App to indicate that you have -Parked- so that your Reservation ' +
		'will not be cancelled.  You were due at: ';

	insert into Email_Message (Receiver_ID, Status_ID, SentTime, MessageText, Res_id, msg_type)
	select Driver_id AS reciever_id, 1 AS status_id, GETDATE() AS senttime, 
	  Fullname + @txt + CAST(FromTime AS VARCHAR(20)) as MessageText, Reservation.id, 'REMINDPARK'  from reservation
			INNER JOIN reservationstatus ON reservation.Status_ID = ReservationStatus.id 
			INNER JOIN driver ON reservation.Driver_ID = driver.id
	  where statusdesc = 'PENDING' AND DATEDIFF(MINUTE, FromTime, GETDATE()) > 15 AND 
				Reservation.id NOT IN 
				  (SELECT em2.Res_ID FROM EMail_Message em2 WHERE  
				    (em2.msg_type='REMINDPARK' AND em2.Status_ID=2));

	SET @txt = ' >>> Your parking reservation at UCO was cancelled.  You were due to arrive at: ';

	insert into Email_Message (Receiver_ID, Status_ID, SentTime, MessageText, Res_id, msg_type)
	select Driver_id AS reciever_id, 1 AS status_id, GETDATE() AS senttime, 
	  Fullname + @txt + CAST(FromTime AS VARCHAR(20)) as MessageText, Reservation.id, 'CANCELLED' from reservation
			INNER JOIN reservationstatus ON reservation.Status_ID = ReservationStatus.id 
			INNER JOIN driver ON reservation.Driver_ID = driver.id
	  where statusdesc = 'PENDING' AND DATEDIFF(MINUTE, FromTime, GETDATE()) > 30 AND 
				Reservation.id NOT IN 
				  (SELECT em2.Res_ID FROM EMail_Message em2 WHERE  
				    (em2.msg_type='CANCELLED' AND em2.Status_ID=2));

	update Reservation SET Status_ID=2 WHERE Status_ID = 4 AND ID IN 
		(select res_id FROM EMail_Message WHERE msg_type='CANCELLED');

	SET @txt = 'Your parking reservation at UCO was flagged as overextended.  You were due to depart at: ';

	insert into Email_Message (Receiver_ID, Status_ID, SentTime, MessageText, Res_id, msg_type)
	select Driver_id AS reciever_id, 1 AS status_id, GETDATE() AS senttime, 
	  Fullname + @txt + CAST(UntilTime AS VARCHAR(20)) as MessageText, Reservation.id, 'OVEREXTENDED' from reservation
			INNER JOIN reservationstatus ON reservation.Status_ID = ReservationStatus.id 
			INNER JOIN driver ON reservation.Driver_ID = driver.id
	  where statusdesc = 'ACTIVE' AND DATEDIFF(MINUTE, UntilTime, GETDATE()) > 30 AND 
				Reservation.id NOT IN 
				  (SELECT em2.Res_ID FROM EMail_Message em2 WHERE  
				    (em2.msg_type='OVEREXTENDED' AND em2.Status_ID=2));

	update Reservation SET Status_ID=2 WHERE ID IN 
		(select res_id FROM EMail_Message WHERE msg_type='OVEREXTENDED');

	SET @txt = ' >>> This is a reminder to update your Reservation Status if you have vacated the Parking Space.' +
			'Please use the Parking App to indicate that you wish to -Leave-  You were due to depart at: ';

	insert into Email_Message (Receiver_ID, Status_ID, SentTime, MessageText, Res_id, msg_type)
	select Driver_id AS reciever_id, 1 AS status_id, GETDATE() AS senttime, 
	  Fullname + @txt + CAST(UntilTime AS VARCHAR(20)) as MessageText, Reservation.id, 'REMINDVACATE' from reservation
			INNER JOIN reservationstatus ON reservation.Status_ID = ReservationStatus.id 
			INNER JOIN driver ON reservation.Driver_ID = driver.id
	  where statusdesc = 'ACTIVE' AND DATEDIFF(MINUTE, UntilTime, GETDATE()) > 15 AND 
				Reservation.id NOT IN 
				  (SELECT em2.Res_ID FROM EMail_Message em2 WHERE  
				    (em2.msg_type='REMINDVACATE' AND em2.Status_ID=2));


END
GO

