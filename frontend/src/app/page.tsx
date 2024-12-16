"use client";
import { useEffect, useState } from "react";
import { fetchWeatherAlerts, fetchFilterOptions } from "../utils/api";
import { WeatherAlert, FilterOptions, Filters } from "@/types/WeartherAlert";
import Grid from "../components/Grid";
import FiltersComponent from "@/components/FiltersComponent";
import LoadingSpinner from "../components/LoadingSpinner";

export default function Home() {
	const [weatherAlerts, setWeatherAlerts] = useState<WeatherAlert[]>([]);
	const [filterOptions, setFilterOptions] = useState<FilterOptions | null>(
		null
	);
	const [filters, setFilters] = useState<Filters>({});
	const [loading, setLoading] = useState(false);

	// Fetch filter options on page load
	useEffect(() => {
		fetchFilterOptions()
			.then((options) => setFilterOptions(options))
			.catch((err) => console.error(err));
	}, []);

	// Fetch weather alerts when filters change
	useEffect(() => {
		setLoading(true);
		fetchWeatherAlerts(filters)
			.then((alerts) => setWeatherAlerts(alerts))
			.catch((err) => console.error(err))
			.finally(() => setLoading(false));
	}, [filters]);

	const handleFilterChange = (newFilter: Filters) => {
		setFilters((prev) => {
			// Merge new filter with previous filters
			const updatedFilters = { ...prev, ...newFilter };

			// Safely remove empty or undefined filters
			for (const key in updatedFilters) {
				const typedKey = key as keyof Filters; // Assert key type
				if (!updatedFilters[typedKey]) {
					delete updatedFilters[typedKey];
				}
			}

			return updatedFilters;
		});
	};

	return (
		<div className="container mx-auto p-4">
			<h1 className="text-2xl font-bold mb-4">Weather Alerts</h1>

			{filterOptions ? (
				<FiltersComponent
					filterOptions={filterOptions}
					onFilterChange={handleFilterChange}
				/>
			) : (
				<LoadingSpinner />
			)}

			{loading ? <LoadingSpinner /> : <Grid weatherAlerts={weatherAlerts} />}
		</div>
	);
}
