import { WeatherAlert } from "@/types/WeartherAlert";

interface GridProps {
	weatherAlerts: WeatherAlert[];
}

const Grid = ({ weatherAlerts }: GridProps) => (
	<div className="grid grid-cols-1 md:grid-cols-3 gap-4 p-4">
		{weatherAlerts.map((alert) => (
			<div key={alert.id} className="border p-4 rounded shadow hover:shadow-md">
				<h3 className="font-bold capitalize bg-slate-100 p-1 mb-2">
					{alert.event}
				</h3>
				<p className="px-1">
					<span className="font-semibold">Location:</span>{" "}
					{alert.geographicDomain}
				</p>
				<p className="px-1">
					<span className="font-semibold">Color:</span> {alert.riskMatrixColor}
				</p>
				<p className="px-1">
					<span className="font-semibold">Certainty:</span> {alert.certainty}
				</p>
				<p className="px-1">
					<span className="font-semibold">Severity:</span> {alert.severity}
				</p>
			</div>
		))}
	</div>
);

export default Grid;
