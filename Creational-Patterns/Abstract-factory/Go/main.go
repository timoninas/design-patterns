package main

import (
	"fmt"
	"patterns/Creational-Patterns/Abstract-factory/Go/abstract"
)

func main() {
	db := abstract.NewAbstractFactory("db").(abstract.Database)
	fs := abstract.NewAbstractFactory("fs").(abstract.File)

	db.PutData("name", "Track1")
	fmt.Println(db.GetData("name"))

	fs.CreateFile("name", "Track2")
	fmt.Println(fs.GetFile("name"))
}
