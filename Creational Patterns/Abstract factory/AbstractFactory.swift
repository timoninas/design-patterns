//
//  AbstractFactory.swift
//  AbstractFactory
//
//  Created by Антон Тимонин on 13.02.2020.
//  Copyright © 2020 Антон Тимонин. All rights reserved.
//

import Foundation

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
