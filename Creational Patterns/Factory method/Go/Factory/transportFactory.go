package Factory

type Car struct {
	WheelsCount int
	Name        string
}

type Helycopter struct {
	Propeller int
	Name      string
}

type TransportFactory struct {
	wheelsCount int
	propeller   int
}

func NewTransportFactory(wheelsCount int, propeller int) TransportFactory {
	return TransportFactory{
		wheelsCount: wheelsCount,
		propeller:   propeller,
	}
}

func (tf TransportFactory) NewHelycopter(name string) Helycopter {
	return Helycopter{
		Propeller: tf.propeller,
		Name:      name,
	}
}

func (tf TransportFactory) NewCar(name string) Car {
	return Car{
		WheelsCount: tf.wheelsCount,
		Name:        name,
	}
}
