# Паттерн Одиночка

## Листинг 

#### singleton.go -> [Исходный код](https://github.com/timoninas/design-patterns/blob/feature/golang-pattterns/Creational%20Patterns/Singleton/Go/Singleton/singleton.go)

```Go
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
```

#### main.go -> [Исходный код](https://github.com/timoninas/design-patterns/blob/feature/golang-pattterns/Creational%20Patterns/Singleton/Go/main.go)

```Go
package main

import (
	"SomeSingleton/Singleton"
	"log"
)

func main() {
	obj1 := Singleton.GetSingleton()
	obj2 := Singleton.GetSingleton()

	obj1.SetTitle("Template")

	log.Println(obj1)
	log.Println(obj2)

	log.Println(obj1.GetId(), obj2.GetId())

}
```

#### Terminal output

```Terminal
2021/06/27 12:26:08 Init
2021/06/27 12:26:08 &{Template 81}
2021/06/27 12:26:08 &{Template 81}
2021/06/27 12:26:08 81 81
```

