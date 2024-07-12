import pygame as pg
import sys
import time
import json
from bird import Bird
from pipe import Pipe

pg.init()

def save_high_score(score, filename="high_score.json"):
    try:
        with open(filename, "r") as file:
            high_score = json.load(file)
    except FileNotFoundError:
        high_score = 0

    if score > high_score:
        with open(filename, "w") as file:
            json.dump(score, file)

def load_high_score(filename="high_score.json"):
    try:
        with open(filename, "r") as file:
            high_score = json.load(file)
    except FileNotFoundError:
        high_score = 0

    return high_score

class Game:
    def __init__(self):
        self.width = 600
        self.height = 768
        self.scale_factor = 1.5
        self.win = pg.display.set_mode((self.width, self.height))
        self.clock = pg.time.Clock()
        self.move_speed = 250
        self.start_monitoring = False
        self.score = 0
        self.font = pg.font.Font("assets/font.ttf", 24)
        self.score_text = self.font.render("Score: 0", True, (0, 0, 0))
        self.score_text_rect = self.score_text.get_rect(center=(100, 30))

        self.high_score = load_high_score()

        self.restart_text = self.font.render("Restart", True, (0, 0, 0))
        self.restart_text_rect = self.restart_text.get_rect(center=(300, 700))

        self.high_score_text = self.font.render(f"Top Score: {self.high_score}", True, (0, 0, 0))
        self.high_score_text_rect = self.high_score_text.get_rect(center=(300, 750))

        self.bird = Bird(self.scale_factor)

        self.is_enter_pressed = False
        self.is_game_started = True
        self.pipes = []
        self.pipe_generate_counter = 71
        self.setUpBgAndGround()

        self.level_font = pg.font.Font(None, 36)
        self.level_text = "Seviye 1"
        self.congrats_text = ""
        self.congrats_display_time = 0

        self.next_level_button = self.font.render("Devam Etmek", True, (255, 255, 255))
        self.next_level_button_rect = self.next_level_button.get_rect(center=(300, 350))
        self.is_button_displayed = False

        self.gameLoop()

    def gameLoop(self):
        last_time = time.time()
        while True:
            new_time = time.time()
            dt = new_time - last_time
            last_time = new_time

            for event in pg.event.get():
                if event.type == pg.QUIT:
                    pg.quit()
                    sys.exit()
                if event.type == pg.KEYDOWN and self.is_game_started:
                    if event.key == pg.K_RETURN:
                        self.is_enter_pressed = True
                        self.bird.update_on = True
                    if event.key == pg.K_SPACE and self.is_enter_pressed and not self.is_button_displayed:
                        self.bird.flap(dt)
                if event.type == pg.MOUSEBUTTONUP:
                    if self.restart_text_rect.collidepoint(pg.mouse.get_pos()):
                        self.restartGame()
                    if self.is_button_displayed and self.next_level_button_rect.collidepoint(pg.mouse.get_pos()):
                        self.is_button_displayed = False
                        self.is_enter_pressed = True
                        self.bird.update_on = True  # Kuş hareket etmeye devam etsin

            self.updateEverything(dt)
            self.checkCollisions()
            self.checkScore()
            self.drawEverything()
            pg.display.update()
            self.clock.tick(60)

    def restartGame(self):
        self.score = 0
        self.score_text = self.font.render("Score: 0", True, (0, 0, 0))
        self.is_enter_pressed = False
        self.is_game_started = True
        self.bird = Bird(self.scale_factor)
        self.bird.resetPosition()
        self.bird.is_hit = False
        self.pipes.clear()
        self.pipe_generate_counter = 71
        self.bird.update_on = False
        self.level_text = "Seviye 1"
        self.move_speed = 250

    def checkScore(self):
        if len(self.pipes) > 0:
            if (self.bird.rect.left > self.pipes[0].rect_down.left and
                self.bird.rect.right < self.pipes[0].rect_down.right and not self.start_monitoring):
                self.start_monitoring = True
            if self.bird.rect.left > self.pipes[0].rect_down.right and self.start_monitoring:
                self.start_monitoring = False
                self.score += 1
                self.score_text = self.font.render(f"Score: {self.score}", True, (0, 0, 0))
                if self.score > self.high_score:
                    self.high_score = self.score
                    save_high_score(self.high_score)
                if self.score in [6, 12] and not self.is_button_displayed:
                    self.is_enter_pressed = False
                    self.bird.update_on = False  # Kuşu durdur
                    self.is_button_displayed = True

    def checkCollisions(self):
        if len(self.pipes):
            if self.bird.rect.bottom > 568 or \
               (self.bird.rect.colliderect(self.pipes[0].rect_down) or 
                self.bird.rect.colliderect(self.pipes[0].rect_up)):
                self.bird.is_hit = True
                self.bird.image = self.bird.img_list[2]
                self.bird.update_on = False
                self.is_enter_pressed = False
                self.is_game_started = False

    def updateEverything(self, dt):
        if self.is_enter_pressed and not self.is_button_displayed:
            if self.score >= 12:
                if self.level_text != "Seviye 3":
                    self.level_text = "Seviye 3"
                    self.congrats_text = "Tebrikler! Seviye 3"
                    self.congrats_display_time = pg.time.get_ticks()
                self.move_speed = 700

            elif self.score >= 6:
                if self.level_text != "Seviye 2":
                    self.level_text = "Seviye 2"
                    self.congrats_text = "Tebrikler! Seviye 2"
                    self.congrats_display_time = pg.time.get_ticks()
                self.move_speed = 400
           
            else:
                self.move_speed = 250
                self.level_text = "Seviye 1"

            self.ground1_rect.x -= int(self.move_speed * dt)
            self.ground2_rect.x -= int(self.move_speed * dt)

            if self.ground1_rect.right < 0:
                self.ground1_rect.x = self.ground2_rect.right
            if self.ground2_rect.right < 0:
                self.ground2_rect.x = self.ground1_rect.right

            if self.pipe_generate_counter > 70:
                self.pipes.append(Pipe(self.scale_factor, self.move_speed))
                self.pipe_generate_counter = 0
                
            self.pipe_generate_counter += 1

            for pipe in self.pipes:
                pipe.update(dt)

            if len(self.pipes) != 0:
                if self.pipes[0].rect_up.right < 0:
                    self.pipes.pop(0)

        self.bird.update(dt)

    def drawCongratulations(self):
        if self.congrats_text:
            congrats_surface = self.level_font.render(self.congrats_text, True, (0, 0, 0))
            congrats_rect = congrats_surface.get_rect(center=(self.width // 2, self.height // 2))
            self.win.blit(congrats_surface, congrats_rect)
            
            if pg.time.get_ticks() - self.congrats_display_time > 2000:
                self.congrats_text = ""

    def drawEverything(self):
        self.win.blit(self.bg_img, (0, -300))
        for pipe in self.pipes:
            pipe.drawPipe(self.win)
        self.win.blit(self.ground1_img, self.ground1_rect)
        self.win.blit(self.ground2_img, self.ground2_rect)
        self.win.blit(self.bird.image, self.bird.rect)
        self.win.blit(self.score_text, self.score_text_rect)

        level_surface = self.level_font.render(self.level_text, True, (255, 255, 255))
        level_rect = level_surface.get_rect(midtop=(self.width // 2, 10))
        self.win.blit(level_surface, level_rect)

        self.drawCongratulations()

        if self.is_button_displayed:
            pg.draw.rect(self.win, (0, 0, 0), self.next_level_button_rect.inflate(20, 20))
            self.win.blit(self.next_level_button, self.next_level_button_rect)

        if not self.is_game_started:
            self.win.blit(self.restart_text, self.restart_text_rect)
            self.win.blit(self.high_score_text, self.high_score_text_rect)

    def showScores(self):
        high_score = load_high_score()
        showing_scores = True
        while showing_scores:
            for event in pg.event.get():
                if event.type == pg.QUIT:
                    pg.quit()
                    sys.exit()
                if event.type == pg.KEYDOWN:
                    if event.key == pg.K_RETURN:
                        showing_scores = False

            self.win.fill((255, 255, 255))
            high_score_text = self.font.render(f"High Score: {high_score}", True, (0, 0, 0))
            high_score_rect = high_score_text.get_rect(center=(self.width // 2, self.height // 2))
            self.win.blit(high_score_text, high_score_rect)
            pg.display.update()
            self.clock.tick(60)

    def setUpBgAndGround(self):
        self.bg_img = pg.transform.scale_by(pg.image.load("assets/bg.png").convert(), self.scale_factor)
        self.ground1_img = pg.transform.scale_by(pg.image.load("assets/ground.png").convert(), self.scale_factor)
        self.ground2_img = pg.transform.scale_by(pg.image.load("assets/ground.png").convert(), self.scale_factor)

        self.ground1_rect = self.ground1_img.get_rect()
        self.ground2_rect = self.ground2_img.get_rect()

        self.ground1_rect.x = 0
        self.ground2_rect.x = self.ground1_rect.right
        self.ground1_rect.y = 568
        self.ground2_rect.y = 568

if __name__ == "__main__":
    Game()
