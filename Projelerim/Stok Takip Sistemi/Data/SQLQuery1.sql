Create Trigger Azalt
on Satis
After insert
as
Declare @URUN int
Declare @ADET int 
Select @URUN=urunID,@Adet=adet from inserted
Update Urun set Stok=stok-@ADET where urunID=@URUN