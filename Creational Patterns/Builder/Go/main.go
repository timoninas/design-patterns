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
