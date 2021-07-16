# Паттерн Пул объектов 

## Назначение 

Паттерн Пул объектов или Object pool предоставляет для программы ограниченный пул объектов, готовых к использованию.
Когда программе требуется объект, тогда он не инициальзируется, а берется из пула объектов. После использования, объект 
освобождается, для использования его, но уже другим объектом. Может быть так, что все объекты будут заняты, в таком случае
придется ждать освобождения

Отличным примером использования паттерна Object pool, будет загрузка фотографий из интернета. Например, вы 
хотите загрузить сразу 100 фотокарточек. Отправляете запрос на загрузку. Хорошая программа будет загружать одновременно
немного изображений одновременно, используя pool из 5 элементов, к примеру


## Листинг 

#### object-pool.go -> [Исходный код](https://github.com/timoninas/design-patterns/blob/feature/golang-pattterns/Creational-Patterns/Object-pool/Go/pool/object-pool.go)

```Go
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
```

#### main.go -> [Исходный код](https://github.com/timoninas/design-patterns/blob/feature/golang-pattterns/Creational-Patterns/Object-pool/Go/main.go)

```Go
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
```

