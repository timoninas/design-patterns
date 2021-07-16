package main

import (
	"patterns/Creational-Patterns/Singleton/Go/Singleton"
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
