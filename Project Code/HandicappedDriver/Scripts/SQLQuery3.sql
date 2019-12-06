DECLARE @txt VARCHAR(255);

SET @txt = ' >>> This is a reminder that you have a Parking Reservation waiting for you on campus at: ';

insert into Email_Message (Receiver_ID, Status_ID, SentTime, MessageText)
select Driver_id AS reciever_id, 1 AS status_id, GETDATE() AS senttime, 
  Fullname + @txt + CAST(FromTime AS VARCHAR(20)) as MessageText from reservation
		INNER JOIN reservationstatus ON reservation.Status_ID = ReservationStatus.id 
		INNER JOIN driver ON reservation.Driver_ID = driver_id
  where statusdesc = 'ACTIVE' AND DATEDIFF(MINUTE, '2019-12-03 16:55' , FromTime) < 10;



