using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UIElements;

namespace LemonInc.Tools.Packager.Editor.Ui
{
	public class Step
	{
		public string Name { get; }
		public Action Action { get; }
		public bool CanRun { get; }
		public bool Toggled { get; set; }

		public Step(string name, Action action, bool canRun)
		{
			Name = name;
			Action = action;
			CanRun = canRun;
		}
	}
	
	public class SetupStep : VisualElement
	{
		private readonly Label _title;
		private readonly ListView _stepsView;
		private List<Step> _steps;

		public SetupStep(VisualTreeAsset baseUxml)
		{
			baseUxml.CloneTree(this);

			_title = this.Q<Label>();
			_stepsView = this.Q<ListView>();
			
			_stepsView.makeItem = () => new Toggle();
			_stepsView.bindItem = (element, index) =>
			{
				var toggle = (Toggle)element;
				if (toggle == null)
					return;
				
				toggle.style.flexDirection = new StyleEnum<FlexDirection>(FlexDirection.Row);
				toggle.style.alignItems = new StyleEnum<Align>(Align.Center);
				toggle.style.justifyContent = new StyleEnum<Justify>(Justify.SpaceBetween);
				toggle.style.flexGrow = 1;
				toggle.style.paddingLeft = new StyleLength(10);
				toggle.style.paddingRight = new StyleLength(10);
				
				toggle.text = _steps[index].Name;
				toggle.value = _steps[index].Toggled;
				toggle.RegisterValueChangedCallback((evt) => _steps[index].Toggled = evt.newValue);
				toggle.Q<Label>().style.marginLeft = new StyleLength(10);
				toggle.SetEnabled(_steps[index].CanRun);
			};
		}

		public void Bind(string title, List<Step> steps)
		{
			_steps = steps;
			_title.text = title;
			_stepsView.itemsSource = _steps;
		}
		
		public List<Step> GetSteps() => _steps.Where(x => x.Toggled && x.CanRun).ToList();
	}
}