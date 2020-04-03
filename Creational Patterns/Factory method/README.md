# Паттерн Фабричный метод

## Листинг 

#### Factory.swift -> [Исходный код](https://github.com/timoninas/design-patterns/blob/master/Creational%20Patterns/Factory%20method/Factory.swift)

```Swift
enum TransportType {
    case car, helicopter, ship
}

class FactoryTransport {
    static let shared = FactoryTransport()
    
    func createTransport(value: TransportType) -> Transport {
        switch value {
        case .car: return Car()
        case .helicopter: return Helicopter()
        case .ship: return Ship()
        }
    }
}
```

#### Transport.swift -> [Исходный код](https://github.com/timoninas/design-patterns/blob/master/Creational%20Patterns/Factory%20method/Transport.swift)

```Swift
enum Terrain {
    case air, ground, water, underwater
}

protocol Transport {
    var name: String { get }
    var type: Terrain { get }
    
    func startMove()
    func stopMove()
}
```

#### Car.swift -> [Исходный код](https://github.com/timoninas/design-patterns/blob/master/Creational%20Patterns/Factory%20method/Car.swift)

```Swift
class Car: Transport {
    var name: String = "Car WMB-kek"
    
    var type: Terrain = .ground
    
    func startMove() {
        print("Start Ride on the ground")
    }
    
    func stopMove() {
        print("Stop Ride on the ground")
    }
}
```

#### Helicopter.swift -> [Исходный код](https://github.com/timoninas/design-patterns/blob/master/Creational%20Patterns/Factory%20method/Helicopter.swift)

```Swift
class Helicopter: Transport {
    var name: String = "Helicopter OG-4500"
    
    var type: Terrain = .air
    
    func startMove() {
        print("Start Fly Helicopter")
    }
    
    func stopMove() {
        print("Stop Fly Helicopter")
    }
}
```

#### Ship.swift -> [Исходный код](https://github.com/timoninas/design-patterns/blob/master/Creational%20Patterns/Factory%20method/Ship.swift)

```Swift
class Ship: Transport {
    var name: String = "Ship-Shit"
    
    var type: Terrain = .water
    
    func startMove() {
        print("Start Swimming")
    }
    
    func stopMove() {
        print("Stop Swimming")
    }
}
```
