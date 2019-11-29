
class Singleton1 {
    
    private init() {}
    
    private static var uniqueValue: Singleton1?
    
    public func get_instance() -> Singleton1 {
        if Singleton1.uniqueValue == nil {
            Singleton1.uniqueValue = Singleton1()
        }
        return Singleton1.uniqueValue!
    }
}

class Singleton {
    
    private init() {}
    
    private static let uniqueValue = Singleton()
}

