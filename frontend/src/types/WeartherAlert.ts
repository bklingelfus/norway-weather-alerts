export interface WeatherAlert {
	id: number;
	event: string;
	geographicDomain: string;
	riskMatrixColor: string;
	certainty: string;
	severity: string;
}

export interface FilterOptions {
	eventTypes: string[];
	geographicDomains: string[];
	riskMatrixColors: string[];
	certainties: string[];
	severities: string[];
}

export interface Filters {
	eventType?: string;
	geographicDomain?: string;
	riskMatrixColor?: string;
	certainty?: string;
	severity?: string;
}
