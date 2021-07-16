package main

import (
	"fmt"
	"patterns/Creational-Patterns/Builder/Go/Builder"
)

func main() {
	view := Builder.NewViewGenerated("BackgroundView")

	fmt.Println(view)

	view.SetColor(Builder.Green)
	view.SetSize(Builder.Big)

	fmt.Println(view)
}
