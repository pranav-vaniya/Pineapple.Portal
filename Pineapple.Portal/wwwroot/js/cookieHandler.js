window.setCookie = (key, value) => {
	if (value === null) {
		document.cookie = `${key}=; path=/; expires=Thu, 01 Jan 1970 00:00:00 UTC;`;
	} else {
		document.cookie = `${key}=${value}; path=/;`;
	}
};

window.getCookie = (key) => {
	const cookies = document.cookie.split("; ");
	for (const cookie of cookies) {
		const [cookieKey, cookieValue] = cookie.split("=");
		if (cookieKey === key) {
			return cookieValue;
		}
	}
	return null;
};

