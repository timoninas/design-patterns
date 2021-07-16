package main

import (
	"patterns/Creational-Patterns/Object-pool/Go/pool"
)

func main() {
	p := pool.New(3)
	i := 0

	select {
	case obj := <-p:
		obj.Prnt(i)
		p <- obj
		i++
	default:
		return
	}
}
