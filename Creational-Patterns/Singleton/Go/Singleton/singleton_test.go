package Singleton

import (
	"testing"
)

func TestTitleSingleton(t *testing.T) {
	obj1 := GetSingleton()
	obj2 := GetSingleton()

	obj1.SetTitle("TestTitle1")

	if obj2.GetTitle() != obj1.GetTitle() {
		t.Fatal("Title are not equal")
	}
}

func TestIdSingleton(t *testing.T) {
	obj1 := GetSingleton()
	obj2 := GetSingleton()
	obj3 := GetSingleton()

	if obj1.GetTitle() != obj2.GetTitle() || obj2.GetTitle() != obj3.GetTitle() {
		t.Fatal("Id are not equal")
	}
}
