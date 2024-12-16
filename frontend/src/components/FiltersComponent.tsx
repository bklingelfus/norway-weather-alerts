import { FilterOptions, Filters } from "@/types/WeartherAlert";

interface FiltersProps {
	filterOptions: FilterOptions;
	onFilterChange: (filters: Filters) => void;
}

const FiltersComponent = ({ filterOptions, onFilterChange }: FiltersProps) => {
	const handleInputChange = (
		e: React.ChangeEvent<HTMLSelectElement | HTMLInputElement>
	) => {
		const { name, value } = e.target;
		onFilterChange({ [name]: value });
	};

	return (
		<div className="grid grid-cols-2 md:grid-cols-5 gap-4 p-4 bg-gray-100 rounded-lg">
			<select
				name="eventType"
				onChange={handleInputChange}
				className="p-2 border rounded"
			>
				<option value="">Event</option>
				{filterOptions.eventTypes.map((e) => (
					<option key={e} value={e}>
						{e}
					</option>
				))}
			</select>

			<select
				name="geographicDomain"
				onChange={handleInputChange}
				className="p-2 border rounded"
			>
				<option value="">Geographic Domain</option>
				{filterOptions.geographicDomains.map((g) => (
					<option key={g} value={g}>
						{g}
					</option>
				))}
			</select>

			<select
				name="riskMatrixColor"
				onChange={handleInputChange}
				className="p-2 border rounded"
			>
				<option value="">Risk Matrix Color</option>
				{filterOptions.riskMatrixColors.map((r) => (
					<option key={r} value={r}>
						{r}
					</option>
				))}
			</select>

			<select
				name="certainty"
				onChange={handleInputChange}
				className="p-2 border rounded"
			>
				<option value="">Certainty</option>
				{filterOptions.certainties.map((c) => (
					<option key={c} value={c}>
						{c}
					</option>
				))}
			</select>

			<select
				name="severity"
				onChange={handleInputChange}
				className="p-2 border rounded"
			>
				<option value="">Severity</option>
				{filterOptions.severities.map((s) => (
					<option key={s} value={s}>
						{s}
					</option>
				))}
			</select>
		</div>
	);
};

export default FiltersComponent;
