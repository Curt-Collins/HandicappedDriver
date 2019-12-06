		DECLARE @txt VARCHAR(255);

	SET @txt = ' >>> This is a reminder that you have a Parking Reservation waiting for you on campus at: ';

select Driver_id AS reciever_id, 1 AS status_id, GETDATE() AS senttime, 
	  Fullname + @txt + CAST(FromTime AS VARCHAR(20)) as MessageText from reservation
			INNER JOIN reservationstatus ON reservation.Status_ID = ReservationStatus.id 
			INNER JOIN driver ON reservation.Driver_ID = driver_id
	  where statusdesc = 'PENDING' AND DATEDIFF(MINUTE, GETDATE(), FromTime) < 15 AND 
			Reservation.id NOT IN 
			  (SELECT em2.Res_ID FROM EMail_Message em2 WHERE NOT (em2.msg_type='REMINDPARK' AND em2.Status_ID=2));
