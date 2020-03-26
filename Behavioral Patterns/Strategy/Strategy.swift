import Foundation

// Behaviour of sort array
protocol SortBehaviour {
    func sort(_ array: inout [Int])
}

// Classic Bubble [1, 2, 3, 4, 5] Up
class SortBubbleUp: SortBehaviour {
    func sort(_ array: inout [Int]) {
        for _ in 0..<array.count {
            for i in 0..<array.count - 1 {
                if array[i] > array[i+1] {
                    let tmp = array[i]
                    array[i] = array[i+1]
                    array[i+1] = tmp
                }
            }
        }
        
        print("Array: ")
        for i in 0..<array.count {
            print("\(array[i])")
        }
    }
}

// Classic Bubble [5, 4, 3, 2, 1] Down
class SortBubbleDown: SortBehaviour {
    func sort(_ array: inout [Int]) {
        for _ in 0..<array.count {
                for i in 0..<array.count - 1 {
                    if array[i] < array[i+1] {
                        let tmp = array[i]
                        array[i] = array[i+1]
                        array[i+1] = tmp
                    }
                }
            }
        }
}

// Insertion Sort [1, 2, 3, 4, 5] Up
class SortInsertionUp: SortBehaviour {
    func sort(_ array: inout [Int]) {
        for x in 1..<array.count {
            var y = x
            while y > 0 && array[y] < array[y - 1] {
                let tmp = array[y]
                array[y] = array[y-1]
                array[y-1] = tmp
                y -= 1
            }
        }
    }
}

protocol OutputBehaviour {
    func print(_ array: [Int])
}

class PrintLikeCode: OutputBehaviour {
    func print(_ array: [Int]) {
        Swift.print(array, separator: "\n", terminator: "")
    }
}

class PrintSimple: OutputBehaviour {
    func print(_ array: [Int]) {
        Swift.print("Array: ")
        for i in 0..<array.count {
            Swift.print(array[i])
        }
    }
}

class AnyArray {
    let forSort : SortBehaviour
    let forOutput : OutputBehaviour
    
    init(typeSort: SortBehaviour, typeOutput: OutputBehaviour) {
        forSort = typeSort
        forOutput = typeOutput
    }
}

var arrayActions = AnyArray(typeSort: SortInsertionUp(), typeOutput: PrintLikeCode())
var arr = [5, 2, 7, 1, 4, -2, 112]
arrayActions.forSort.sort(&arr)
arrayActions.forOutput.print(arr)
