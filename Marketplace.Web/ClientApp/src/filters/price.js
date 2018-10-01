
export default (value) => {
	var str = new String(value)
	return str.replace(/(\d)(?=(\d\d\d)+([^\d]|$))/g, '$1 ')

}