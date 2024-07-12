import pygame as pg

class Bird(pg.sprite.Sprite):   #Kuş görselini eklenip düzzenlemeleri yapıldı
    def __init__(self,scale_factor):
        super(Bird,self).__init__()
        self.img_list=[pg.transform.scale_by(pg.image.load("assets/birdup.png").convert_alpha(),scale_factor),#kuşun görüntü listesini oluşturur
                       pg.transform.scale_by(pg.image.load("assets/birddown.png").convert_alpha(),scale_factor),
                       pg.transform.scale_by(pg.image.load("assets/birdcrasher.png").convert_alpha(),scale_factor)] 
        self.image_index=0
        self.image=self.img_list[self.image_index]
        self.rect=self.image.get_rect(center=(100,100))#başlangıçtaki kuşun konumu
        self.y_velocity=0#başlangıç hızı
        self.gravity=10#düşerkenki hızı
        self.flap_speed=250#kanat çırparkenki hızı
        self.anim_counter=0
        self.update_on=False#güncelleme
        self.active = True  # Kuşun aktif olduğunu gösteren bayrak
        self.is_hit = False  # Kuşun çarptığını gösteren bayrak1

    def update(self,dt):
        if self.update_on and self.active:
            if not self.is_hit: #1
                self.playAnimation()#kuşu oynatmak için
                self.applyGravity(dt)#kuşun düşmesini sağlar

            else:  # Eğer kuş çarptıysa
                self.image = self.img_list[2]
                #self.image = pg.image.load('sfx/birdcrasher.png')  # Kuş resmini "birdcrasher" adlı bir dosyadan yükle

        if self.rect.y<=0 and self.flap_speed==250:     #kuşun üst tarfa çıkmasını engelller
            self.rect.y=0#üst tarafa yapışır
            self.flap_speed=0
            self.y_velocity=0
        elif self.rect.y>0 and self.flap_speed==0: 
            self.flap_speed=250  
            
        if self.rect.bottom >= 568:  # Eğer kuş zemine düşerse1
            self.is_hit = True  # Kuşu çarpmış olarak işaretle1

    def applyGravity(self,dt):#kuşun düşme hızı ayarlanır
        self.y_velocity+=self.gravity*dt
        self.rect.y+=self.y_velocity

    def flap(self,dt):#kuşun yukarı çıkmasını sağlar
        self.y_velocity=-self.flap_speed*dt          

    def playAnimation(self):#kanat çırpmasını yönetir
        if self.anim_counter==5:
            self.image=self.img_list[self.image_index]
            if self.image_index==0: 
                self.image_index=1
            else: 
                self.image_index=0
            self.anim_counter=0
        self.anim_counter+=1#her güncellemede animasyon sayacı bir artar kanat çıpmasını düzenli çalışmasını sağlar

    def resetPosition(self):#kuşun başlangıç ​​konumuna sıfırlanmasını sağlar
        self.rect.center=(100,100)
        self.y_velocity=0
        self.anim_counter=0
        self.is_hit = False  # Çarpma durumunu sıfırla
        self.image = self.img_list[0]  # Normal görüntüyü ayarla
        #self.image_index = 0
        #self.image = self.img_list[self.image_index]  # Normal görüntüyü ayarla
   

