//
//  Ship.swift
//  Factory
//
//  Created by Антон Тимонин on 10.02.2020.
//  Copyright © 2020 Антон Тимонин. All rights reserved.
//

import Foundation


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
