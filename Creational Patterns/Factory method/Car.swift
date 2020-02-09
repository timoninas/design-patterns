//
//  Car.swift
//  Factory
//
//  Created by Антон Тимонин on 10.02.2020.
//  Copyright © 2020 Антон Тимонин. All rights reserved.
//

import Foundation

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
