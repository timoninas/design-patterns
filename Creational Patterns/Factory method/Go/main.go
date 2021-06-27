package main

import (
	"Factory/factory"
	"fmt"
	"net/http"
)

func main() {
	// MARK:- Family Factory
	newFamily := factory.NewFamilyFactory("TTT Family")

	fmt.Println(newFamily("Anton Timonin", 21))

	// MARK:- Transport Factory
	newTransportFactory := factory.NewTransportFactory(4, 1)

	car := newTransportFactory.NewCar("BMW")
	helycopter := newTransportFactory.NewHelycopter("Aero III")

	fmt.Println(car)
	fmt.Println(helycopter)

	// MARK:- Create simple client
	client := factory.NewSimpleHTTPClient()

	req := http.Request{}
	client.Do(&req)
	fmt.Println(client)
}
