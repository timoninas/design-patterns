package main

import (
	"builder/Builder"
	"fmt"
)

func main() {
	view := Builder.NewViewGenerated("BackgroundView")

	fmt.Println(view)

	view.SetColor(Builder.Green)
	view.SetSize(Builder.Big)

	fmt.Println(view)
}
