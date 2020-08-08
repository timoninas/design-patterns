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
        Swift.print("\n")
        Swift.print(array, separator: "\n", terminator: "")
        Swift.print("\n")
    }
    
}

class PrintSimple: OutputBehaviour {
    func print(_ array: [Int]) {
        Swift.print("\nArray: ")
        for i in 0..<array.count {
            Swift.print(array[i])
        }
        Swift.print("\n")
    }
}

class AnyArray {
    private var forSort : SortBehaviour
    private var forOutput : OutputBehaviour
    
    init(typeSort: SortBehaviour, typeOutput: OutputBehaviour) {
        forSort = typeSort
        forOutput = typeOutput
    }
    
    func setSortBehaviour(newSortBehav: SortBehaviour) {
        forSort = newSortBehav
    }
    
    func setOutputBehaviour(newOutputBehav: OutputBehaviour) {
        forOutput = newOutputBehav
    }
    
    func sort(array: inout [Int]) {
        forSort.sort(&array)
    }
    
    func print(array: [Int]) {
        forOutput.print(array)
    }
}

var arrayActions = AnyArray(typeSort: SortInsertionUp(), typeOutput: PrintLikeCode())
var arr = [5, 2, 7, 1, 4, -2, 112]
arrayActions.sort(array: &arr)
arrayActions.print(array: arr)

arrayActions.setSortBehaviour(newSortBehav: SortBubbleDown())
arrayActions.setOutputBehaviour(newOutputBehav: PrintSimple())
arrayActions.sort(array: &arr)
arrayActions.print(array: arr)
