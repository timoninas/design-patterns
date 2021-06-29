package prototype

import (
	"testing"
)

func TestPrototype(t *testing.T) {
	obj1 := NewUser("Anton", "1111", 1393.0)
	obj2 := obj1.Clone()

	obj2.SetNumber("55555")

	if obj1.GetNumber() != obj2.GetNumber() {
		t.Fatal("Numbers are equal")
	}

	if obj1.GetName() != obj2.GetName() {
		t.Fatal("Names are not equal")
	}
}