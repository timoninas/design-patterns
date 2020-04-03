# Паттерн Прототип

## Назначение

Позволяет копировать объекты, не уточняя детали копирования. То есть нам нужно передать только объект, клон которого мы хотим получить, дальнейшая реализация нас не интересует.

## Листинг 

#### Prototype.swift -> [Исходный код](https://github.com/timoninas/design-patterns/blob/master/Creational%20Patterns/Prototype/Prototype.swift)


```Swift
public protocol Shape {
    init(_ prototype: Self)
    
    var x: Int { get }
    var y: Int { get }
}

extension Shape {
    public func clone() -> Self {
        return type(of: self).init(self)
    }
}

class Rectangle: Shape {
    var x: Int
    var y: Int
    var color: String
    
    init(x: Int, y: Int, color: String) {
        self.x = x
        self.y = y
        self.color = color
    }
    
    required convenience init(_ prototype: Rectangle) {
        self.init(x: prototype.x, y: prototype.y, color: prototype.color)
    }
}

class Circle: Shape {
    var x: Int
    var y: Int
    var size: String

    init(x: Int, y: Int, size: String) {
        self.x = x
        self.y = y
        self.size = size
    }
    
    required convenience init(_ prototype: Circle) {
        self.init(x: prototype.x, y: prototype.y, size: prototype.size)
    }
}

```
