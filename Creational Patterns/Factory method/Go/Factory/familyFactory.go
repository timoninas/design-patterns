package Factory

type Person struct {
	Name   string
	Age    int
	Family string
}

func NewFamilyFactory(family string) func(name string, age int) Person {
	return func(name string, age int) Person {
		return Person{
			Name:   name,
			Age:    age,
			Family: family,
		}
	}
}
