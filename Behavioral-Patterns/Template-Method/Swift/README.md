# Паттерн Шаблонный метод

## Назначение

Когда у вас есть объекты с последовательно-одинаковым поведением, тогда можно подписать их
на протокол объединяющий их и запускать templateMethod, в котором будут запускаться методы 
в нужном смысловом порядке. А конкретные методы вы будете реализовывать уже в конкретном объекте.
Может случиться так что какой-либо метод не нужен для данного объекта, в этом случае можно переопределить (обязательно) 
на бездействие. Шаблонный метод использует ViewController, когда запускается

ViewConroller запускает методы в такой последовательности:

* loadView()
* viewDidLoad()
* viewWillAppear()
* viewDidAppear()

## Листинг 

#### Command.swift -> [Исходный код](https://github.com/timoninas/design-patterns/blob/master/Behavioral%20Patterns/Template%20Method/Template%20Method.swift)



```Swift
class Document {
    
    // Шаблонный метод
    final func templateMethod() {
        addDocument()
        encryptDocument()
        openDocument()
        readDocument()
    }
    
    func addDocument() {
        preconditionFailure()
    }
    
    func openDocument() {
        print("open Document")
    }
    
    func encryptDocument() {
        preconditionFailure()
    }
    
    func readDocument() {
        preconditionFailure()
    }
}

class PDFDocument: Document {
    override func addDocument() {
        print("add PDF document")
    }
    
    override func encryptDocument() {
    }
    
    override func readDocument() {
        print("read PDF document")
    }
}

class EncryptedDocument: Document {
    override func addDocument() {
        print("add crypted document")
    }
    
    override func encryptDocument() {
        print("encrypt document")
    }
    
    override func openDocument() {
        print("open encrypted document")
    }
    
    override func readDocument() {
        print("read encrypted document")
    }
}

func board() {
    print("\n|----------------------------------|\n")
}

func main() {
    let doc1 = PDFDocument()
    doc1.templateMethod()
    
    board()
    
    let doc2 = EncryptedDocument()
    doc2.templateMethod()
}
```

#### Output

```Console
add PDF document
open Document
read PDF document

|----------------------------------|

add crypted document
encrypt document
open encrypted document
read encrypted document
```
