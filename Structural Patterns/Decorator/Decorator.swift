import UIKit

protocol PersonalComputerProtocol {
    func getSpecification() -> String
    func getPrice() -> Int
}

class BasePC: PersonalComputerProtocol {
    func getSpecification() -> String {
        return "PC"
    }
    
    func getPrice() -> Int {
        return 500
    }
}

class DecoratorPC: PersonalComputerProtocol {
    private var typePC: PersonalComputerProtocol
    
    required init(newPC: PersonalComputerProtocol) {
        self.typePC = newPC
    }
    
    func getSpecification() -> String {
        return typePC.getSpecification()
    }
    
    func getPrice() -> Int {
        return typePC.getPrice()
    }
}

class RtxPC: DecoratorPC {
    required init(newPC: PersonalComputerProtocol) {
        super.init(newPC: newPC)
    }
    
    override func getSpecification() -> String {
        return super.getSpecification() + " with RTX"
    }
    
    override func getPrice() -> Int {
        return super.getPrice() + 200
    }
}

class CoolerPC: DecoratorPC {
    required init(newPC: PersonalComputerProtocol) {
        super.init(newPC: newPC)
    }
    
    override func getSpecification() -> String {
        return super.getSpecification() + " with Cooler"
    }
    
    override func getPrice() -> Int {
        return super.getPrice() + 100
    }
}

func separator() {
    print("\n-------- -------- --------\n")
}


func main() {
    var myPC: PersonalComputerProtocol = BasePC()
    print(myPC.getPrice())
    print(myPC.getSpecification())
    
    separator()
    
    myPC = RtxPC(newPC: myPC)
    print(myPC.getPrice())
    print(myPC.getSpecification())
    
    separator()
    
    myPC = CoolerPC(newPC: myPC)
    print(myPC.getPrice())
    print(myPC.getSpecification())
    
    separator()
}

main()
