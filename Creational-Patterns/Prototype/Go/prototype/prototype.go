package prototype

import "fmt"

type UserInterface interface {
	SetNumber(number string)
	GetNumber() string
	GetName() string
	Clone() UserInterface
}

type User struct {
	cash float64
	Name string
	Number string
}

func NewUser(name string, number string, cash float64) User {
	return User {
		cash: cash,
		Name: name,
		Number: number,
	}
}

func (u *User) SetNumber(number string) {
	u.Number = number
}

func (u *User) GetNumber() string {
	return u.Number
}

func (u *User) GetName() string {
	return u.Name
}

// MARK:- Clone method
func (u *User) Clone() UserInterface {
	return &User {
		cash: u.cash,
		Name: u.Name,
		Number: u.Number,
	}
}

func TestWorkPrototype() {
	user1 := NewUser("Anton", "77777", 1488.93)
	user2 := user1.Clone()

	user2.SetNumber("11111")

	fmt.Println(user1)
	fmt.Println(user2)
}
