# Паттерн Фабричный метод

## Листинг 

#### FamilyFactory.go -> [Исходный код](https://github.com/timoninas/design-patterns/blob/feature/golang-pattterns/Creational%20Patterns/Factory%20method/Go/Factory/FamilyFactory.go)

```Go
package factory

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
```

#### TransportFactory.go -> [Исходный код](https://github.com/timoninas/design-patterns/blob/feature/golang-pattterns/Creational%20Patterns/Factory%20method/Go/Factory/TransportFactory.go)

```Go
package factory

type Car struct {
	WheelsCount int
	Name        string
}

type Helycopter struct {
	Propeller int
	Name      string
}

type TransportFactory struct {
	wheelsCount int
	propeller   int
}

func NewTransportFactory(wheelsCount int, propeller int) TransportFactory {
	return TransportFactory{
		wheelsCount: wheelsCount,
		propeller:   propeller,
	}
}

func (tf TransportFactory) NewHelycopter(name string) Helycopter {
	return Helycopter{
		Propeller: tf.propeller,
		Name:      name,
	}
}

func (tf TransportFactory) NewCar(name string) Car {
	return Car{
		WheelsCount: tf.wheelsCount,
		Name:        name,
	}
}
```

#### ClientFactory.go -> [Исходный код](https://github.com/timoninas/design-patterns/blob/feature/golang-pattterns/Creational%20Patterns/Factory%20method/Go/Factory/ClientFactory.go)

```Go
package factory

import (
	"log"
	"net/http"
)

type DoRequest interface {
	Do(req *http.Request) (*http.Response, error)
}

// MockHttpClient
type MockHTTPClient struct{}

func NewMockHTTPClient() DoRequest {
	return MockHTTPClient{}
}

func (c MockHTTPClient) Do(req *http.Request) (*http.Response, error) {
	return &http.Response{}, nil
}

// HttpClient
type SimpleHTTPClient struct{}

func NewSimpleHTTPClient() DoRequest {
	return SimpleHTTPClient{}
}

func (c SimpleHTTPClient) Do(req *http.Request) (*http.Response, error) {
	var client http.Client
	resp, err := client.Get("http://golang.org/")

	if err != nil {
		log.Println(err)
		return nil, err
	}

	log.Println(resp)
	return resp, nil
}
```
