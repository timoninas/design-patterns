# Паттерн Строитель

## Назначение 

Паттерн Строитель или Builder предназначен для облегчения процесса сложной инициализации мы делаем настройку объекта в
паттерне Строитель. Builder - конструирует сложный объект

## Различие Builder с Abstract Factory

Различие паттерна строитель с паттерном абстрактная фабрика в том, что
строитель поэтапно конструирует объект, в то время как паттерн абстрактная фабрика
создает семейство объектов: простых или сложных

## Листинг 

#### someBuilder.go -> [Исходный код](https://github.com/timoninas/design-patterns/blob/feature/golang-pattterns/Creational%20Patterns/Builder/Go/Builder/someBuilder.go)

```Go
package builder

// MARK:- Color of object
type Color string

const (
	Green Color = "green"
	White       = "white"
	Black       = "black"
	None        = ""
)

// MARK:- Size of object
type Size float64

const (
	Small  Size = 1.0
	Medium      = 10.0
	Big    Size = 25.0
)

type ViewGenerated struct {
	Name  string
	Size  Size
	Color Color
}

func NewViewGenerated(name string) ViewGenerated {
	return ViewGenerated{
		Name:  name,
		Size:  Small,
		Color: None,
	}
}

func (v *ViewGenerated) SetColor(color Color) {
	v.Color = color
}

func (v *ViewGenerated) SetSize(size Size) {
	v.Size = size
}
```

#### main.go -> [Исходный код](https://github.com/timoninas/design-patterns/blob/feature/golang-pattterns/Creational%20Patterns/Builder/Go/main.go)

```Go
package main

import (
	"builder/builder"
	"fmt"
)

func main() {
	view := builder.NewViewGenerated("BackgroundView")

	fmt.Println(view)

	view.SetColor(builder.Green)
	view.SetSize(builder.Big)

	fmt.Println(view)
}
```
