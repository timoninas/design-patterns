package pool

import (
	"fmt"
)

type (
	SObject struct{}

	Pool chan *SObject
)

func (o *SObject) Prnt(name int) {
	fmt.Println("[LOG]", name)
}

func New(total int) Pool {
	p := make(Pool, total)

	for i := 0; i < total; i++ {
		p <- new(SObject)
	}

	return p
}
