//
//  Helicopter.swift
//  Factory
//
//  Created by Антон Тимонин on 10.02.2020.
//  Copyright © 2020 Антон Тимонин. All rights reserved.
//

import Foundation

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
