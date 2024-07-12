USE [KanBankasi]
GO
/****** Object:  Trigger [dbo].[Azal]    Script Date: 12.01.2024 23:24:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Trigger [dbo].[Azal]
on [dbo].[TransferBagis]
After insert
as
Declare @TRANSFER int
Declare @ADET int 
Select @TRANSFER=transferID,@ADET=adet from inserted
Update Transfer set kanStok=kanStok-@ADET where transferID=@TRANSFER