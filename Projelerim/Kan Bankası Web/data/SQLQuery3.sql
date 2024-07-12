USE [KanBankasi]
GO
/****** Object:  Trigger [dbo].[Azalt]    Script Date: 12.01.2024 23:23:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Trigger [dbo].[Azalt]
on [dbo].[KanBagisi]
After insert
as
Declare @KANSTOK int
Declare @ADET int 
Select @KANSTOK=kanStoguID,@ADET=adet from inserted
Update KanStogu set kanStok=kanStok-@ADET where kanStoguID=@KANSTOK