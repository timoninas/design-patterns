# Паттер Смотрящий

## Тип - поведенческий

## Назначение
Когда изменяется состояние одного ViewMain, вам нужно чтобы на других подписанных на него ViewObserver1, ViewObserver1, ... была обновленная информация. Для этого нужен паттерн Смотрящий. В ViewMain будет содержаться пул объектов, которые будут наблюдать за ним. При осуществлении какой-нибудь бизнес логики, ViewMain будет отправлять всем смотрящим за ним объектам notify, что ViewMain перешел в другое состояние.

## Листинг
#### Observer.swift
```Swift
// Протокол (интерфейс) на который мы подписываем наших смотрящих
protocol Observer: class { // смотрящими могут быть только классы
    func update()
}

class Notifier {
    private var state: UInt32 = {
        return arc4random_uniform(10)
     }()
    
    private var observers = [Observer]()
    
    func add(subject: Observer) { // Добавление объекта в пул объектов
        observers.append(subject)
        print(#function)
    }
    
    func remove(subject: Observer) { // Удаление объекта в пул объектов
        if let index = observers.firstIndex(where: { $0 === subject }) {
            observers.remove(at: index)
            print(#function)
        }
    }
    
    func notify() { // Отправка уведомление всем объектам
        print(#function)
        observers.forEach { (subject) in
            subject.update()
        }
    }
    
    func businessLogic() { // Бизнес логика класса, после которой нужно отправит уведомления
        print("\n\nBUSINESS LOGIC №\(state)!\n\n")
        notify()
        print(#function)
    }
}

// Сами классы смотрящие, в которых нужно будет обновить информацию 
class Watcher: Observer {  
    func update() {
        let num = arc4random_uniform(10) * arc4random_uniform(10)
        print("Watcher is watching \(num)")
    }
}

class Docher: Observer {
    func update() {
        let num = arc4random_uniform(10) * arc4random_uniform(10)
        print("Docher is doing \(num)")
    }
}

class Speacher: Observer {
    func update() {
        let num = arc4random_uniform(10) * arc4random_uniform(10)
        print("Speacher is speaking \(num)")
    }
}

func main() {
    let obs1 = Watcher()
    let obs2 = Docher()
    let obs3 = Speacher()
    
    let notify = Notifier()
    
    notify.add(subject: obs1)
    notify.add(subject: obs3)
    
    notify.businessLogic()
    
    notify.remove(subject: obs1)
    
    notify.add(subject: obs2)
    notify.add(subject: obs1)
    
    notify.businessLogic()
}
```
#### Output
```Swift
add(subject:)
add(subject:)

BUSINESS LOGIC №0!

notify()
Watcher is watching 2
Speacher is speaking 10
businessLogic()
remove(subject:)
add(subject:)
add(subject:)

BUSINESS LOGIC №0!

notify()
Speacher is speaking 45
Docher is doing 49
Watcher is watching 4
businessLogic()
```
