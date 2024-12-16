import { WeatherAlert, FilterOptions, Filters } from "@/types/WeartherAlert";

const BASE_URL = "http://localhost:5000/api/weatheralert";

export const fetchWeatherAlerts = async (
	filters: Filters = {}
): Promise<WeatherAlert[]> => {
	console.log(filters);
	const query = new URLSearchParams(
		filters as Record<string, string>
	).toString();
	const response = await fetch(`${BASE_URL}?${query}`);
	if (!response.ok) throw new Error("Failed to fetch weather alerts.");
	return await response.json();
};

export const fetchFilterOptions = async (): Promise<FilterOptions> => {
	const response = await fetch(`${BASE_URL}/filters`);
	if (!response.ok) throw new Error("Failed to fetch filter options.");
	return await response.json();
};
