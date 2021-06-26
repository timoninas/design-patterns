package main

import (
	"factory/Factory"
	"fmt"
	"net/http"
)

func main() {
	// MARK:- Family Factory
	newFamily := Factory.NewFamilyFactory("TTT Family")

	fmt.Println(newFamily("Anton Timonin", 21))

	// MARK:- Transport Factory
	newTransportFactory := Factory.NewTransportFactory(4, 1)

	car := newTransportFactory.NewCar("BMW")
	helycopter := newTransportFactory.NewHelycopter("Aero III")

	fmt.Println(car)
	fmt.Println(helycopter)

	// MARK:- Create simple client
	client := Factory.NewSimpleHTTPClient()

	req := http.Request{}
	client.Do(&req)
	fmt.Println(client)
}
