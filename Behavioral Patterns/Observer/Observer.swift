import UIKit


protocol Observer: class {
    func update()
}

class Notifier {
    private var state: UInt32 = {
        return arc4random_uniform(10)
     }()
    
    private var observers = [Observer]()
    
    func add(subject: Observer) {
        observers.append(subject)
        print(#function)
    }
    
    func remove(subject: Observer) {
        if let index = observers.firstIndex(where: { $0 === subject }) {
            observers.remove(at: index)
            print(#function)
        }
    }
    
    func notify() {
        print(#function)
        observers.forEach { (subject) in
            subject.update()
        }
    }
    
    func businessLogic() {
        print("\n\nBUSINESS LOGIC №\(state)!\n\n")
        notify()
        print(#function)
    }
}

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

main()
