




protocol Observer: class {
    func update()
}

class Notifier {
    var state: Int = {
        return Int(arc4random_uniform(100))
    }()
    
    private lazy var observers = [Observer]()
    
    func add(_ subject: Observer) {
        print(#function)
        observers.append(subject)
        
    }
    
    func remove(_ subject: Observer) {
        if let index = observers.firstIndex(where: {$0 === subject}) {
            observers.remove(at: index)
            print(#function)
        }
        
    }
    
    func notify() {
        print(#function)
        for value in observers {
            value.update()
        }
    }
    
    func businessLogic() {
        print(#function)
        print("Lol kek businessLogic cheburek ⚗️")
        notify()
    }
}

class Observer1: Observer {
    func update() {
        print("Observer1, DO WATCH")
    }
}

class Observer2: Observer {
    func update() {
        print("Observer2, play in Metro Exodus")
    }
}

func main() {
    let notifier = Notifier()
    let obs1 = Observer1()
    let obs2 = Observer2()
    
    notifier.add(obs1)
    notifier.businessLogic()
    
    print("\n----- SEPARATOR -----\n")
    
    notifier.remove(obs1)
    notifier.add(obs2)
    notifier.add(obs1)
    notifier.businessLogic()
}

main()

