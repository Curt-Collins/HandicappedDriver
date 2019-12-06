
DECLARE @email_id NVARCHAR(450), @id INT, @max_id INT, @query NVARCHAR(1000), @msg VARCHAR(255)

SELECT @id=MIN(id), @max_id=MAX(id) FROM [EMail_Message] WHERE Status_ID=1

WHILE @id<=@max_id
BEGIN
    SET @email_id=
	  (SELECT DISTINCT emailaddress from Driver  
	    INNER JOIN EMail_Message ON Driver.ID=EMail_Message.Receiver_ID
		WHERE EMail_Message.id=@id)

	SET @msg=(SELECT messagetext from EMail_Message WHERE id=@id)

    EXEC msdb.dbo.sp_send_dbmail @profile_name='Handicapped Parking',
                        @recipients=@email_id,
                        @subject='Reserved Parking Space Reminder from UCO',
                        @body=@msg

	UPDATE EMail_Message SET Status_ID=2 WHERE id=@id

    SELECT @id=MIN(id) FROM EMail_Message where id>@id AND Status_ID=1
END