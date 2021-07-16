# Паттерн Прототип

## Назначение

Позволяет копировать объекты, не уточняя детали копирования. То есть нам нужно передать только объект, клон которого мы хотим получить, дальнейшая реализация нас не интересует.

## Листинг 

#### prototype.go -> [Исходный код](https://github.com/timoninas/design-patterns/blob/feature/golang-pattterns/Creational%20Patterns/Prototype/Go/prototype/prototype.go)


```Go
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

```
