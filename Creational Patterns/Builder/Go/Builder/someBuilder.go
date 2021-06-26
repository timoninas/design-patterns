package builder

// MARK:- Color of object
type Color string

const (
	Green Color = "green"
	White       = "white"
	Black       = "black"
	None        = ""
)

// MARK:- Size of object
type Size float64

const (
	Small  Size = 1.0
	Medium      = 10.0
	Big    Size = 25.0
)

type ViewGenerated struct {
	Name  string
	Size  Size
	Color Color
}

func NewViewGenerated(name string) ViewGenerated {
	return ViewGenerated{
		Name:  name,
		Size:  Small,
		Color: None,
	}
}

func (v *ViewGenerated) SetColor(color Color) {
	v.Color = color
}

func (v *ViewGenerated) SetSize(size Size) {
	v.Size = size
}
