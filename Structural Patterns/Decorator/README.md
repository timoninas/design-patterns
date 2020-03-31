# Паттер Декоратор

## Назначение

Когда у вас есть объект, которому нужно добавлять какие-то новые свойства, не изменяя его исходное состояние. 

Отличный пример - это добавление фильтров на изображение. Исходное состояние - то которое изображение имело при загрузке. Далее мы можем использовать наложение фильтров, таким образом декорируя его. И в соответствии с тем, какие фильтры нам нужны, в такие классы декоратора мы и будем отправлять наше изображение

## Реализация

Реализация паттерна Декоратор заключается в том, что он использует не наследование, а агрегацию, то есть он не наследует поведение какого-либо класса, а содержит этот самый класс и использует его поведение.


## Демонстрация работы


![Decorator](https://github.com/timoninas/design-patterns/blob/master/Structural%20Patterns/Decorator/Decorator.gif)


## Листинг 

```Swift
import Foundation

\\ Необходимый протокол для подписания декоратора и стартового объекта class PC
\\ Тк мы выделяем PC в отдельный класс, а не наследуем от декоратора, то мы можем
\\ декорировать также и другие объекты, подписанные на протокол PCProtocol

protocol PCProtocol: class { 
    func getPrice() -> Int   
    func getConfiguration() -> String 
}


\\ Начальный объект
class PC: PCProtocol {
    func getPrice() -> Int {
        return 500
    }
    
    func getConfiguration() -> String {
        return "PC"
    }
}

\\ Декоратор для кастомизации Начального объекта
\\ Просто декоратор никто не вызывает, вызывают обычно его классы-потомки
class PCDecorator: PCProtocol {
    private var PCtype: PCProtocol
    
    required init(pc: PCProtocol) {
        self.PCtype = pc
    }
    
    func getPrice() -> Int {
        return PCtype.getPrice()
    }
    
    func getConfiguration() -> String {
        return PCtype.getConfiguration()
    }
}

\\ Унаследованный класс1 от PCDecorator
class PCTrx: PCDecorator {
    override func getPrice() -> Int {
        return super.getPrice() + 250
    }
    
    override func getConfiguration() -> String {
        return super.getConfiguration() + " with TRX"
    }
}

\\ Унаследованный класс2 от PCDecorator
class PCWaterCooler: PCDecorator {
    override func getPrice() -> Int {
        return super.getPrice() + 100
    }
    
    override func getConfiguration() -> String {
        return super.getConfiguration() + " with Cooler"
    }
}

\\ Унаследованный класс3 от PCDecorator
class PCRam: PCDecorator {
    override func getPrice() -> Int {
        return super.getPrice() + 150
    }
    
    override func getConfiguration() -> String {
        return super.getConfiguration() + " with 8GB Ram"
    }
}

\\ Демонстрация работы паттерна Декоратор

func main() {
  var pc: PCProtocol = PC() \\ Создание начального объекта
  
  pc = PCRam(pc)          \\ Добавляем PC RAM
  pc = PCWaterCooler(pc)  \\ Добавляем PC Water Cooler
  pc = PCTrx(pc)          \\ Добавляем PC Trx
  
  \\ Получаем компьютер с ram, water cooler, trx
}
```
