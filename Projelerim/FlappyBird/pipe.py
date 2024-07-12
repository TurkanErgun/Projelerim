import pygame as pg
from random import randint
class Pipe:# baştma metodurdur borular oluşurken çagırır boruların yönünün ayarlamaları yapıldı
    def __init__(self,scale_factor,move_speed):
        self.img_up=pg.transform.scale_by(pg.image.load("assets/pipeup.png").convert_alpha(),scale_factor)
        self.img_down=pg.transform.scale_by(pg.image.load("assets/pipedown.png").convert_alpha(),scale_factor)
        self.rect_up=self.img_up.get_rect()#yukarı
        self.rect_down=self.img_down.get_rect()#aşagı
        self.pipe_distance=200#boorular arası mesafe
        self.rect_up.y=randint(250,520)#yukarı konum
        self.rect_up.x=600#yukarı başlangıç
        self.rect_down.y=self.rect_up.y-self.pipe_distance-self.rect_up.height
        self.rect_down.x=600#aşgı başlangıc
        self.move_speed=move_speed#hareket hızı

    def drawPipe(self,win):#ekranda gösterir boruyu
        win.blit(self.img_up,self.rect_up)#yuksrı
        win.blit(self.img_down,self.rect_down)#asagı

    def update(self,dt):#konumu günceller
        self.rect_up.x-=int(self.move_speed*dt)
        self.rect_down.x-=int(self.move_speed*dt) 
        
        
                        