# Паттерн Абстрактная фабрика

## Листинг 

#### AbstractFactory.swift -> [Исходный код](https://github.com/timoninas/design-patterns/blob/master/Creational%20Patterns/Abstract%20factory/AbstractFactory.swift)

```Swift
protocol AbstractFactory {
    static func createCompactCar() -> CompactCar
    static func createSportCar() -> SportCar;
    static func createPickupCar() -> PickupCar;
}


class FactoryBMW: AbstractFactory {
    static func createCompactCar() -> CompactCar {
        return CompactBMW()
    }
    
    static func createSportCar() -> SportCar {
        return SportBWM()
    }
    
    static func createPickupCar() -> PickupCar {
        return PickupBMW()
    }
}


class FactoryAudi: AbstractFactory {
    static func createCompactCar() -> CompactCar {
        return CompactAudi()
    }
    
    static func createSportCar() -> SportCar {
        return SportAudi()
    }
    
    static func createPickupCar() -> PickupCar {
        return PickupAudi()
    }
}


class FactoryMercedes: AbstractFactory {
    static func createCompactCar() -> CompactCar {
        return CompactMercedes()
    }
    
    static func createSportCar() -> SportCar {
        return SportMercedes()
    }
    
    static func createPickupCar() -> PickupCar {
        return PickupMercedes()
    }
}

```

#### CompactCar.swift -> [Исходный код](https://github.com/timoninas/design-patterns/blob/master/Creational%20Patterns/Abstract%20factory/CompactCar.swift)

```Swift
protocol CompactCar {
    var name: String { get }
    
    func slowRide() -> String
}

class CompactBMW: CompactCar {
    var name: String = "BMW X5"
    
    func slowRide() -> String {
        return "Wa are drive slowly in a \(name)"
    }
}

class CompactAudi: CompactCar {
    var name: String = "Audi TT"
    
    func slowRide() -> String {
        return "Wa are drive slowly in a \(name)"
    }
}

class CompactMercedes: CompactCar {
    var name: String = "Mercdec LL"
    
    func slowRide() -> String {
        return "Wa are drive slowly in a \(name)"
    }
}

```


#### PickupCar.swift -> [Исходный код](https://github.com/timoninas/design-patterns/blob/master/Creational%20Patterns/Abstract%20factory/PickupCar.swift)

```Swift
protocol PickupCar {
    var name: String { get }
    var length: Double { get }
    
    func getPowerOfCar() -> String
}


class PickupBMW: PickupCar {
    var name: String = "BMW Crasher v2000"
    
    var length: Double = 1000
    
    func getPowerOfCar() -> String {
        return "PickUp \(name) has power about \(length)"
    }
}


class PickupAudi: PickupCar {
    var name: String = "Audi Detracker II"
    
    var length: Double = 999.999
    
    func getPowerOfCar() -> String {
        return "PickUp \(name) has power about \(length)"
    }
}


class PickupMercedes: PickupCar {
    var name: String = "Mercedes Fivik"
    
    var length: Double = 1000.0001
    
    func getPowerOfCar() -> String {
        return "PickUp \(name) has power about \(length)"
    }
}
```


#### SportCar.swift -> [Исходный код](https://github.com/timoninas/design-patterns/blob/master/Creational%20Patterns/Abstract%20factory/SportCar.swift)

```Swift
protocol SportCar {
    var name: String { get }
    
    func getInfo() -> String
}


class SportBWM: SportCar {
    var name: String = "BMW i8"
    
    func getInfo() -> String {
        return "\(name) has a max speed 315 k/h"
    }
}


class SportAudi: SportCar {
    var name: String = "Audi 8S"
    
    func getInfo() -> String {
        return "\(name) has a max speed 320 k/h"
    }
}


class SportMercedes: SportCar {
    var name: String = "Mercedes Benz"
    
    func getInfo() -> String {
        return "\(name) has a max speed 298 k/h"
    }
}

```




