# Паттерн Абстрактная фабрика

## Листинг 

#### abstract-factory.go -> [Исходный код](https://github.com/timoninas/design-patterns/blob/feature/golang-pattterns/Creational-Patterns/Abstract-factory/Go/abstract/abstract-factory.go)

```Go
package abstract

type (
	Database interface {
		GetData(string) string
		PutData(string, string)
	}

	mongoDb struct {
		database map[string]string
	}

	mqlite struct {
		database map[string]string
	}
)

func (mdb *mongoDb) GetData(key string) string {
	return mdb.database[key]
}

func (mdb *mongoDb) PutData(key string, value string) {
	mdb.database[key] = value
}

type (
	File interface {
		GetFile(string) string
		CreateFile(string, string)
	}

	ntfs struct {
		system map[string]string
	}
)

func (fs *ntfs) GetFile(filename string) string {
	return fs.system[filename]
}

func (fs *ntfs) CreateFile(filename string, content string) {
	fs.system[filename] = content
}

func NewAbstractFactory(variety string) interface{} {
	switch variety {
	case "db":
		return &mongoDb{make(map[string]string)}

	case "fs":
		return &ntfs{make(map[string]string)}

	default:
		return nil
	}
}

```

#### main.go -> [Исходный код](https://github.com/timoninas/design-patterns/blob/feature/golang-pattterns/Creational-Patterns/Abstract-factory/Go/main.go)

```Go
package main

import (
	"fmt"
	"patterns/Creational-Patterns/Abstract-factory/Go/abstract"
)

func main() {
	db := abstract.NewAbstractFactory("db").(abstract.Database)
	fs := abstract.NewAbstractFactory("fs").(abstract.File)

	db.PutData("name", "Track1")
	fmt.Println(db.GetData("name"))

	fs.CreateFile("name", "Track2")
	fmt.Println(fs.GetFile("name"))
}
```
