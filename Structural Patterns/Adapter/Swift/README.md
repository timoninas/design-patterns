# Паттерн Адаптер 

## Назначение

Паттерн адаптер преобразует интерфейс одного класса к интерфейсу другого класса, который нам необходимо где-то использовать. Данный паттерн адаптирует несовместимый интерфейс одного класса к интерфейсу другого класса, для дальнейшей работы

## Листинг 

#### Adapter.swift -> [Исходный код](https://github.com/timoninas/design-patterns/blob/master/Structural%20Patterns/Adapter/Adapter.swift)

```Swift
import UIKit

// protocol to adapter
protocol SimpleMessage {
    func getMessage() -> String
}


// Adapter
final class AdapterMessage: SimpleMessage {
    var asciiMessage: ASCIIMessage
    
    init(asciiMessage: ASCIIMessage) {
        self.asciiMessage = asciiMessage
    }
    
    private func numberToCharacter(number: Int) -> String {
        if let uni = UnicodeScalar(number) {
            return String(Character(uni))
        }
        return ""
    }
    
    func getMessage() -> String {
        var message: String = ""
        for value in asciiMessage.getASCIIMessage() {
            message += numberToCharacter(number: value)
        }
        
        return message
    }
}

// Adapteee
final class ASCIIMessage {
    private var message: [Int]
    init(message: [Int]) {
        self.message = message
    }
    
    func getASCIIMessage() -> [Int] {
        return message
    }
}

func main() {
    let msgInt = [72, 101, 108, 108, 111]
    let asciiMsg = ASCIIMessage(message: msgInt)

    print("Current ASCII message: \(asciiMsg.getASCIIMessage())")

    let adapterAsciiMsg = AdapterMessage(asciiMessage: asciiMsg)
    
    print("Adapted ASCII message: \(adapterAsciiMsg.getMessage())")
}
```

#### Output

```Console
// Current ASCII message: [72, 101, 108, 108, 111]
// Adapted ASCII message: Hello
```

## Другие названия 

Обертка, Wrapper
