//
//  PickupCar.swift
//  AbstractFactory
//
//  Created by Антон Тимонин on 13.02.2020.
//  Copyright © 2020 Антон Тимонин. All rights reserved.
//

import Foundation

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

