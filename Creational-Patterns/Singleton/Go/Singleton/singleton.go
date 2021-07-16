package Singleton

import (
	"log"
	"math/rand"
	"sync"
)

// Singleton должен иметь приватный конструктор
// И конструироваться объект должен единожды
// Гетеры и сетеры должны быть публичными (сетеры не всегда)

type singleton struct {
	title string
	id    int
}

var instance Singleton = nil
var config = new(sync.Once)

func GetSingleton() Singleton {
	config.Do(func() {
		log.Println("Init")
		instance = new(singleton)
		instance.setId()
	})
	return instance
}

type Singleton interface {
	GetTitle() string
	SetTitle(newTitle string)
	GetId() int
	setId()
}

func (s *singleton) GetTitle() string {
	return s.title
}

func (s *singleton) SetTitle(newTitle string) {
	s.title = newTitle
}

func (s *singleton) setId() {
	s.id = rand.Intn(100)
}

func (s *singleton) GetId() int {
	return s.id
}
